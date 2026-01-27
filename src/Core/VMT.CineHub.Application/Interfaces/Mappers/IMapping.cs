using VMT.CineHub.Application.DTOs.Authentication.Register;
using VMT.CineHub.Domain.Entities;

namespace VMT.CineHub.Application.Interfaces.Mappers;
public interface IMapping
{
    User MapUser(RegisterCommandRequestDto dto, string personId);
    Person MapPerson(RegisterCommandRequestDto dto);
}