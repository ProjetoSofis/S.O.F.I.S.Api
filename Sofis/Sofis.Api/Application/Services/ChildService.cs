using Sofis.Api.Application.Contracts;
using Sofis.Api.Application.Dtos;
using Sofis.Api.Application.Interfaces;
using Sofis.Api.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Sofis.Api.Application.Services
{
    public class ChildService : IChildService
    {
        private readonly IChildRepository _childRepository;

        public ChildService(IChildRepository childRepository)
        {
            _childRepository = childRepository;
        }

        public async Task<IEnumerable<ChildDto>> GetAllAsync()
        {
            var children = await _childRepository.GetAllAsync();
            return children.Select(MapToDto);
        }

        public async Task<ChildDto?> GetByIdAsync(Guid id)
        {
            var child = await _childRepository.GetByIdAsync(id);
            if (child == null)
            {
                return null;
            }
            return MapToDto(child);
        }

        public async Task<ChildDto> RegisterChildAsync(CreateChildDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new ValidationException("Nome é obrigatório");
            }
            if (dto.BirthDate > DateTime.UtcNow.Date)
            {
                throw new ValidationException("Data de nascimento não pode ser no futuro");
            }
            var child = new Child
            {
                Id = Guid.NewGuid(),
                Name = dto.Name.Trim(),
                BirthDate = dto.BirthDate.Date,
                Responsible = dto.Responsible?.Trim()
            };
            await _childRepository.AddAsync(child);

            return MapToDto(child);
        }

        private ChildDto MapToDto(Child c) =>
            new ChildDto
            {
                Id = c.Id,
                Name = c.Name,
                BirthDate = c.BirthDate,
                Responsible = c.Responsible
            };
    }
}
