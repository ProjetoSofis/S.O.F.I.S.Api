using Sofis.Api.Application.Contracts;
using Sofis.Api.Application.Dtos.GuardianDtos;
using Sofis.Api.Application.Interfaces;
using Sofis.Api.Domain.Entities;

namespace Sofis.Api.Application.Services
{
    public class GuardianService : IGuardianService
    {
        private readonly IGuardianRepository _guardianRepository;
        private readonly IChildRepository _childRepository;
        public GuardianService(IGuardianRepository guardianRepository, IChildRepository childRepository)
        {
            _guardianRepository = guardianRepository;
            _childRepository = childRepository;
        }
        public async Task<GuardianDto> CreateGuardianAsync(CreateGuardianDto dto)
        {
            var child = await _childRepository.GetByIdAsync(dto.ChildId);
            if (child == null)
            {
                throw new KeyNotFoundException($"Criança com ID {dto.ChildId} não encontrada");
            }
            var guardian = new Guardian
            {
                Name = dto.Name,
                Cpf = dto.Cpf,
                Kinship = dto.Kinship,
                Phone = dto.Phone ?? string.Empty,
                Email = dto.Email,
            };
            guardian.Children.Add(child);
            var createdGuardian = await _guardianRepository.AddAsync(guardian);
            return MapToDto(createdGuardian);
        }

        public async Task DeleteGuardianAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<GuardianDto>> GetAllGuardiansAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<GuardianDto?> GetGuardianByIdAsync(Guid id)
        {
            throw new NotImplementedException();

        }

        public Task UpdateGuardianAsync(Guid id, CreateGuardianDto dto)
        {
            throw new NotImplementedException();
        }
        private GuardianDto MapToDto(Guardian g) => new GuardianDto
        {
            Id = g.Id,
            Name = g.Name,
            Cpf = g.Cpf,
            Kinship = g.Kinship,
            Phone = g.Phone,
            Email = g.Email,
            ChildId = g.Children.FirstOrDefault()?.Id ?? Guid.Empty

        };
    }
}
