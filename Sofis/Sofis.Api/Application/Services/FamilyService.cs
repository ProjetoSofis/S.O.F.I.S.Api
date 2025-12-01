using Sofis.Api.Application.Contracts;
using Sofis.Api.Application.Dtos.EmployeeDtos;
using Sofis.Api.Application.Dtos.FamilyDtos;
using Sofis.Api.Application.Dtos.GuardianDtos;
using Sofis.Api.Application.Interfaces;
using Sofis.Api.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Sofis.Api.Application.Services
{
    public class FamilyService : IFamilyService
    {
        private readonly IGuardianRepository _guardianRepository;
        private readonly IChildRepository _childRepository;
        private readonly IFamilyRepository _familyRepository;
        private readonly IChildRepository _childRepository;

        public FamilyService(
            IFamilyRepository familyRepository,
            IChildRepository childRepository)
        {
            _guardianRepository = guardianRepository;
            _childRepository = childRepository;
            _familyRepository = familyRepository;
            _childRepository = childRepository;
        }

        public async Task<GuardianDto> RegisterGuardianForChildAsync(CreateGuardianDto dto)
        {
            var child = await _childRepository.GetByIdAsync(dto.ChildId);
            if (child == null)
            {
                throw new ValidationException("Criança não encontrada");
            }

            var existingGuardian = await _guardianRepository.GetByCpfAsync(dto.Cpf);
            if (existingGuardian != null)
            {
                throw new ValidationException("Já existe um responsável cadastrado com esse CPF.");
            }

        public async Task<FamilyDto?> GetByCpf(string cpf)
        {
            var family = await _familyRepository.GetByCpfAsync(cpf);
            if (family == null)
                throw new Exception("Familiar não encontrado");

            return MapToDto(family);
        }

        public async Task<FamilyDto?> GetByIdAsync(Guid id)
        {
            var family = await _familyRepository.GetByIdAsync(id);
            if (family == null)
                throw new Exception("Familiar não encontrado");

            return MapToDto(family);
        }

        public async Task<FamilyDto> RegisterFamilyAsync(CreateFamilyDto dto)
        {
            var existingFamily = await _familyRepository.GetByCpfAsync(dto.Cpf);
            if (existingFamily != null)
                throw new Exception("Já existe um familiar cadastrado com esse CPF.");

            var child = await _childRepository.GetByIdAsync(dto.ChildId);
            if (child == null)
                throw new Exception($"Criança com ID {dto.ChildId} não encontrada.");

            var family = new Family
            {
                Name = dto.Name,
                Cpf = dto.Cpf,
                Kinship = dto.Kinship,
                Address = dto.Address,
                Phone = dto.Phone,
                Email = dto.Email,
                ChildId = dto.ChildId
            };

            await _familyRepository.AddFamilyAsync(family);

            return MapToDto(family);
        }

        public async Task<GuardianDto?> GetGuardianByIdAsync(Guid id)
        {
            var existingFamily = await _familyRepository.GetByIdAsync(dto.Id);
            if (existingFamily == null)
                throw new Exception("Familiar não encontrado.");

            existingFamily.Name = dto.Name;
            existingFamily.Cpf = dto.Cpf;
            existingFamily.Kinship = dto.Kinship;
            existingFamily.Address = dto.Address;
            existingFamily.Phone = dto.Phone;
            existingFamily.Email = dto.Email;

            await _familyRepository.UpdateFamilyAsync(existingFamily);
            return MapToDto(existingFamily);
        }

        private FamilyDto MapToDto(Family f) =>
            new FamilyDto
            {
                Id = f.Id,
                Name = f.Name,
                Cpf = f.Cpf,
                Kinship = f.Kinship,
                Address = f.Address,
                Phone = f.Phone,
                Email = f.Email,
                ChildId = f.ChildId
            };
    }
}
