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
        private DateTime nowDate = DateTime.Today;
        private DateOnly now = DateOnly.FromDateTime(DateTime.Today);


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
            // Comentário - Vinicius: Obter o DateTime atual (apenas a data, com a hora zerada)
            nowDate = DateTime.Today;

            // Comentário - Vinicius: Converter para DateOnly
            now = DateOnly.FromDateTime(nowDate);
            if (dto.BirthDate > now)
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
                BirthDate = dto.BirthDate,
                Responsible = dto.Responsible.Trim(),
                MomName = dto.MomName,
                DadName = dto.DadName
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
            // Comentário - Vinicius: Obter o DateTime atual (apenas a data, com a hora zerada)
            nowDate = DateTime.Today;

            // Comentário - Vinicius: Converter para DateOnly
            now = DateOnly.FromDateTime(nowDate);
            if (dto.BirthDate > now)
            {
                throw new ValidationException("Data de nascimento não pode ser no futuro");
            }
            var child = new Child
            {
                Name = dto.Name.Trim(),
                BirthDate = dto.BirthDate,
                Responsible = dto.Responsible.Trim(),
                MomName = dto.MomName,
                DadName = dto.DadName,
                Cpf = dto.Cpf
            };
            await _childRepository.UpdateAsync(child);
            return MapToDto(child);
        }

        
        public async Task<ChildDto?> GetByCpfASync(string cpf)
        {
            var child = _childRepository.GetByCpfAsync(cpf);
            if (child == null)
            {
                return await Task.FromResult<ChildDto?>(null);
            }
            return await Task.FromResult<ChildDto?>(MapToDto(child.Result));
        }
        public async Task<IEnumerable<ChildDto>> GetByNameAsync(string name)
        {
            var childs = await _childRepository.GetByNameAsync(name);
            return childs.Select(MapToDto);
        }

        private ChildDto MapToDto(Child c) =>
            new ChildDto
            {
                Id = c.Id,
                Name = c.Name,
                BirthDate = c.BirthDate,
                Responsible = c.Responsible,
                MomName = c.MomName,
                DadName = c.DadName,
                Cpf = c.Cpf
                
            };

        public async Task<ChildDto> UpdateChildAsync(Guid id, UpdateChildDto dto)
        {
            var existingChild = await _childRepository.GetByIdAsync(id);
            if (existingChild == null)
            {
                throw new Exception("Criança não encontrada");
            }
            existingChild.Name = dto.Name;
            existingChild.Cpf = dto.Cpf;
            existingChild.BirthDate = dto.BirthDate;
            existingChild.DadName = dto.DadName;
            existingChild.MomName = dto.MomName;
            existingChild.Responsible = dto.Responsible;
            await _childRepository.UpdateAsync(existingChild);
            
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
                Cpf = c.Cpf,
                MomName = c.MomName,
                DadName = c.DadName,
                Responsible = c.Responsible,
            };
    }
}
