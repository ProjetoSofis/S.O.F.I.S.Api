using Sofis.Api.Application.Contracts;
using Sofis.Api.Application.Dtos;
using Sofis.Api.Application.Dtos.ChildDtos;
using Sofis.Api.Application.Dtos.GuardianDtos;
using Sofis.Api.Application.Interfaces;
using Sofis.Api.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Sofis.Api.Application.Services
{
    public class ChildService : IChildService
    {
        private readonly IChildRepository _childRepository;
        private readonly IFamilyRepository _familyRepository;
        private DateTime nowDate = DateTime.Today;
        private DateOnly now = DateOnly.FromDateTime(DateTime.Today);


        public ChildService(IChildRepository childRepository, IFamilyRepository familyRepository)
        {
            _childRepository = childRepository;
            _familyRepository = familyRepository;
        }

        public async Task<IEnumerable<ChildDto>> GetAllAsync()
        {
            var children = await _childRepository.GetAllAsync();
            return children.Select(MapToDto);
        }

        public async Task<ChildDto?> GetByIdAsync(Guid id)
        {
            var childWithFamilyAndGuardians = await _childRepository.GetByIdWithFamilyAndGuardians(id);
            var childWithReports = await _childRepository.GetByIdWithReportsAsync(id);

            if (childWithFamilyAndGuardians == null)
            {
                return null;
            }

            
            
            return MapToDto(childWithReports);
        }

        public async Task<ChildDto> RegisterChildAsync(CreateChildDto dto)
        {
            var existingChild = await _childRepository.GetByCpfAsync(dto.Cpf);
            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new ValidationException("Nome é obrigatório");
            }

            now = DateOnly.FromDateTime(DateTime.Today);

            if (dto.BirthDate > now)
            {
                throw new ValidationException("Data de nascimento não pode ser no futuro");
            }

            var familyExists = await _familyRepository.GetByIdAsync(dto.FamilyId);
            if (familyExists == null)
            {
                throw new ValidationException($"Família com ID {dto.FamilyId} não encontrada");
            }

            if (existingChild != null)
            {
                throw new ValidationException("CPF já cadastrado");
            }

            var child = new Child
            {
                Name = dto.Name.Trim(),
                Cpf = dto.Cpf,
                BirthDate = dto.BirthDate,
                Responsible = dto.Responsible.Trim(),
                CodigoEol = dto.CodigoEol,
                Endereco = dto.Endereco,
                UnidadeEscolar = dto.UnidadeEscolar,
                AnoEscolar = dto.AnoEscolar,
                MomName = dto.MomName,
                DadName = dto.DadName,
                FamilyId = dto.FamilyId
            };

            await _childRepository.AddAsync(child);

            return MapToDto(child);
        }

        public async Task<ChildDto> UpdateChildAsync(Guid id, UpdateChildDto dto)
        {
            var existingChild = await _childRepository.GetByIdAsync(id);

            if (existingChild == null)
            {
                throw new Exception("Criança não encontrada");
            }

            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new ValidationException("Nome é obrigatório");
            }

            now = DateOnly.FromDateTime(DateTime.Today);

            if (dto.BirthDate > now)
            {
                throw new ValidationException("Data de nascimento não pode ser no futuro");
            }

            existingChild.Name = dto.Name.Trim();
            existingChild.BirthDate = dto.BirthDate;
            existingChild.Responsible = dto.Responsible.Trim();
            existingChild.CodigoEol = dto.CodigoEol;
            existingChild.Endereco = dto.Endereco;
            existingChild.UnidadeEscolar = dto.UnidadeEscolar;
            existingChild.AnoEscolar = dto.AnoEscolar;
            existingChild.MomName = dto.MomName;
            existingChild.DadName = dto.DadName;
            existingChild.Cpf = dto.Cpf;


            await _childRepository.UpdateAsync(existingChild);

            return MapToDto(existingChild);
        }


        public async Task<ChildDto?> GetByCpfASync(string cpf)
        {
            var child = await _childRepository.GetByCpfAsync(cpf);

            if (child == null)
            {
                return null;
            }

            return MapToDto(child);
        }

        public async Task<IEnumerable<ChildDto>> GetByNameAsync(string name)
        {
            var childs = await _childRepository.GetByNameAsync(name);
            return childs.Select(MapToDto);
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


        private GuardianDto MapGuardianToDto(Guardian g) => new GuardianDto
        {
            Id = g.Id,
            Name = g.Name,
            Cpf = g.Cpf,
            Email = g.Email,
            Phone = g.Phone,
            Kinship = g.Kinship,
        };


        private ChildDto MapToDto(Child c)
        {
            var dto = new ChildDto
            {
                Id = c.Id,
                Name = c.Name,
                Cpf = c.Cpf,
                MomName = c.MomName,
                DadName = c.DadName,
                Responsible = c.Responsible,
                BirthDate = c.BirthDate,
                CodigoEol = c.CodigoEol,
                Endereco = c.Endereco,
                UnidadeEscolar = c.UnidadeEscolar,
                AnoEscolar = c.AnoEscolar,
                FamilyId = c.FamilyId,
                Guardians = c.Guardians?
                    .Select(MapGuardianToDto)
                    .ToList() ?? new List<GuardianDto>(),
                reports = c.Reports?.ToList() ?? new List<Report>()
            };

            if (c.Family != null)
            {
                dto.FamilyName = c.Family.Name;
            }

            return dto;
        }
    }
}