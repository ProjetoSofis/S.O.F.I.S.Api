using Sofis.Api.Application.Contracts;
using Sofis.Api.Application.Dtos;
using Sofis.Api.Application.Dtos.ChildDtos;
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
            var existingChild = await _childRepository.GetByCpfAsync(dto.Cpf);
            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new ValidationException("Nome é obrigatório");
            }
            if (dto.BirthDate > DateTime.UtcNow.Date)
            {
                throw new ValidationException("Data de nascimento não pode ser no futuro");
            }
            if (existingChild != null)
            {
                throw new ValidationException("CPF já cadastrado");
            }
            var child = new Child
            {
                Name = dto.Name.Trim(),
                Cpf = dto.Cpf,
                BirthDate = dto.BirthDate.Date,
                Responsible = dto.Responsible.Trim()
            };
            await _childRepository.AddAsync(child);

            return MapToDto(child);
        }

        public async Task<ChildDto> UpdateChildAsync(UpdateChildDto dto)
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
                Name = dto.Name.Trim(),
                BirthDate = dto.BirthDate,
                Responsible = dto.Responsible.Trim()
            };
            await _childRepository.UpdateAsync(child);
            return MapToDto(child);
        }

        public async Task DeleteChildAsync(Guid id)
        {
            var existingChild = await _childRepository.GetByIdAsync(id);
            if (existingChild == null)
            {
                throw new ValidationException("Criança não encontrada");
            }
            await _childRepository.DeleteAsync(id);
        }

        private ChildDto MapToDto(Child c) =>
            new ChildDto
            {
                Id = c.Id,
                Name = c.Name,
                BirthDate = c.BirthDate,
                Responsible = c.Responsible
            };

        public Task<ChildDto?> GetByCpfASync(string cpf)
        {
            var child = _childRepository.GetByCpfAsync(cpf);
            if (child == null)
            {
                return Task.FromResult<ChildDto?>(null);
            }
            return Task.FromResult<ChildDto?>(MapToDto(child.Result));
        }
    }
}
