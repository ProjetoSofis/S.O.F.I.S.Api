using Sofis.Api.Application.Contracts;
using Sofis.Api.Application.Dtos.GuardianDtos;
using Sofis.Api.Application.Interfaces;
using Sofis.Api.Domain.Entities;

namespace Sofis.Api.Application.Services
{
    public class GuardianService : IGuardianService
    {
        private readonly IGuardianRepository _guardianRepository;
        private readonly IFamilyRepository _familyRepository;
        public GuardianService(IGuardianRepository guardianRepository, IFamilyRepository familyRepository)
        {
            _guardianRepository = guardianRepository;
            _familyRepository = familyRepository;
        }
        public async Task<GuardianDto> CreateGuardianAsync(CreateGuardianDto dto)
        {
            var family = await _familyRepository.GetByIdAsync(dto.FamilyId);
            if (family == null)
            {
                throw new KeyNotFoundException($"Família com id {dto.FamilyId}");
            }
            var guardian = new Guardian
            {
                Name = dto.Name,
                Cpf = dto.Cpf,
                Phone = dto.Phone ?? string.Empty,
                Email = dto.Email,
                FamilyId = dto.FamilyId
            };
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
            var guardian = await _guardianRepository.GetByIdAsync(id);
            if (guardian == null)
            {
                throw new KeyNotFoundException($"Responsável com id {id} não encontrado.");
            }
            var family = await _familyRepository.GetByIdAsync(guardian.FamilyId);
            if (family == null)
            {
                throw new KeyNotFoundException($"Família com id {guardian.FamilyId} não encontrada.");
            }
            return MapToDto(guardian);

        }

        public Task UpdateGuardianAsync(Guid id, CreateGuardianDto dto)
        {
            throw new NotImplementedException();
        }
        private GuardianDto MapToDto(Guardian g) => new GuardianDto
        {
            Name = g.Name,
            Cpf = g.Cpf,
            Phone = g.Phone,
            Email = g.Email,
            FamilyId = g.FamilyId
        };
    }
}
