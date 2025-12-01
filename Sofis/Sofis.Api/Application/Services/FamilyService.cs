using Sofis.Api.Application.Contracts;
using Sofis.Api.Application.Dtos.EmployeeDtos;
using Sofis.Api.Application.Dtos.FamilyDtos;
using Sofis.Api.Application.Dtos.GuardianDtos;
using Sofis.Api.Application.Interfaces;
using Sofis.Api.Domain.Entities;
using Sofis.Api.Infrastructure.Persistence.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Sofis.Api.Application.Services
{
    public class FamilyService : IFamilyService
    {
        private readonly IFamilyRepository _familyRepository;
        private readonly IGuardianRepository _guardianRepository;
        public FamilyService(IFamilyRepository familyRepository, IGuardianRepository guardianRepository)
        {
            _familyRepository = familyRepository;
            _guardianRepository = guardianRepository;
        }

        public async Task<FamilyDto> CreateFamilyAsync(CreateFamilyDto dto)
        {
            var family = new Family
            {
                Name = dto.Name,
                Address = dto.Address
            };

            var createdFamily = await _familyRepository.AddAsync(family);
            return MapToDto(createdFamily);
            
        }

        public async Task<ICollection<FamilyDto>> GetAllFamiliesAsync()
        {
            var families = await _familyRepository.GetAllAsync();
            return families.Select(MapToDto).ToList();

        }

        public async Task<FamilyDto?> GetFamilyByIdAsync(Guid id)
        {
            var family = await _familyRepository.GetFamilyDetailsAsync(id);
            if (family == null) return null;

            return MapToDto(family);
        }

        public async Task<FamilyDto?> GetFamilyByGuardianCpfAsync(string cpf)
        {
            // Nota: O IGuardianRepository precisaria de um método GetByCpfAsync(string cpf) para ser ideal.
            // Assumindo que o repositório Guardian implementa essa lógica:
            // var guardian = await _guardianRepository.GetByCpfAsync(cpf);

            // Simulação (Se o método GetByCpfAsync não existir, isso falhará na compilação)
            // Se o repositório só tiver GetAll, a performance seria ruim:
            var guardian = await _guardianRepository.GetByCpfAsync(cpf);
            if (guardian == null) {
                return null;
            };

            return await GetFamilyByIdAsync(guardian.FamilyId);
        }

        public Task UpdateFamilyAsync(Guid id, CreateFamilyDto dto)
        {
            // Lógica de atualização
            throw new NotImplementedException();
        }

        public Task DeleteFamilyAsync(Guid id)
        {
            // Lógica de deleção
            throw new NotImplementedException();
        }
        private FamilyDto MapToDto(Family f) => new FamilyDto
        {
            Name = f.Name,
            Address = f.Address,
            GuardianCount = f.Guardians.Count,
            ChildrenCount = f.RelationedChildren.Count
        };
    }
}
