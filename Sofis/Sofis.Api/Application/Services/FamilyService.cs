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
        public FamilyService(IGuardianRepository guardianRepository, IChildRepository childRepository, IFamilyRepository familyRepository)
        {
            _guardianRepository = guardianRepository;
            _childRepository = childRepository;
            _familyRepository = familyRepository;
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

            var guardian = new Guardian
            {
                Name = dto.Name,
                Cpf = dto.Cpf,
                Kinship = dto.Kinship,
                Address = dto.Address,
                Phone = dto.Phone,
                Email = dto.Email,
                //FamilyId = child.FamilyId
            };
            await _guardianRepository.AddAsync(guardian);
            return MapToDto(guardian);

        }

        public async Task<GuardianDto?> GetGuardianByIdAsync(Guid id)
        {
            var guardian = await _guardianRepository.GetByIdAsync(id);
            if (guardian == null)
            {
                throw new Exception("Responsável não encontrado.");
            }
            return MapToDto(guardian);
        }
        public async Task DeleteGuardianAsync(Guid id)
        {
            var existing = await _guardianRepository.GetByIdAsync(id);
            if (existing == null)
            {
                throw new ValidationException("Responsável não encontrado.");
            }
            await _guardianRepository.DeleteAsync(id);
        }


        private GuardianDto MapToDto(Guardian g) =>
                new GuardianDto
                {
                    Id = g.Id,
                    Name = g.Name,
                    Cpf = g.Cpf,
                    Kinship = g.Kinship,
                    Address = g.Address,
                    Phone = g.Phone,
                    Email = g.Email,
                    FamilyId = g.FamilyId
                };





        //    public async Task DeleteFamilyAsync(Guid id)
        //    {
        //        var existingFamily = await GetByIdAsync(id);
        //        if (existingFamily == null)
        //        {
        //            throw new ValidationException("Family not found.");
        //        }
        //        await _familyRepository.DeleteFamilyAsync(id);
        //    }

        //    public async Task<IEnumerable<FamilyDto>> GetAllAsync()
        //    {
        //        var familys = await _familyRepository.GetAllAsync();
        //        return familys.Select(MapToDto);
        //    }

        //    public async Task<FamilyDto?> GetByCpf(string cpf)
        //    {
        //        var Family = await _familyRepository.GetByCpfAsync(cpf);
        //        if (Family == null)
        //        {
        //            throw new Exception("Familiar não encontrado");
        //        }
        //        return MapToDto(Family);
        //    }

        //    public async Task<FamilyDto?> GetByIdAsync(Guid id)
        //    {
        //        var family = await _familyRepository.GetByIdAsync(id);
        //        if (family == null)
        //        {
        //            throw new Exception("Familiar não encontrado");
        //        }
        //        return MapToDto(family);
        //    }

        //    public async Task<FamilyDto> RegisterFamilyAsync(CreateFamilyDto dto)
        //    {
        //        var existingFamily = await _familyRepository.GetByCpfAsync(dto.Cpf);
        //        if (existingFamily != null)
        //        {
        //            throw new Exception("Já existe um familiar cadastrado com esse CPF.");
        //        };
        //        var family = new Family
        //        {
        //            Name = dto.Name,
        //            Kinship = dto.Kinship,
        //            Cpf = dto.Cpf,
        //            Address = dto.Address,
        //            Phone = dto.Phone,
        //            Email = dto.Email
        //        };
        //        await _familyRepository.AddFamilyAsync(family);
        //        return MapToDto(family);
        //    }

        //    public async Task<FamilyDto> UpdateFamilyAsync(UpdateFamilyDto dto)
        //    {
        //        var existingFamily = await _familyRepository.GetByIdAsync(dto.Id);
        //        if (existingFamily == null)
        //        {
        //            throw new Exception("Familiar não encontrado.");
        //        }
        //        existingFamily.Name = dto.Name;
        //        existingFamily.Cpf = dto.Cpf;
        //        existingFamily.Kinship = dto.Kinship;
        //        existingFamily.Address = dto.Address;
        //        existingFamily.Phone = dto.Phone;
        //        existingFamily.Email = dto.Email;
        //        await _familyRepository.UpdateFamilyAsync(existingFamily);
        //        return MapToDto(existingFamily);
        //    }
        //    private FamilyDto MapToDto(Family f) =>
        //    new FamilyDto
        //    {
        //        Id = f.Id,
        //        Name = f.Name,
        //        Cpf = f.Cpf,
        //        Kinship = f.Kinship,
        //        Address = f.Address,
        //        Phone = f.Phone,
        //        Email = f.Email
        //    };

    }
}
