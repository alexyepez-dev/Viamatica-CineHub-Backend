using VMT.CineHub.Application.DTOs.Authentication.Register;
using VMT.CineHub.Application.Interfaces.Mappers;
using VMT.CineHub.Application.Interfaces.UseCases;
using VMT.CineHub.Domain.Entities;
using VMT.CineHub.Domain.ValueObjects;

namespace VMT.CineHub.Application.Mappers;
internal sealed class Mapping
(
    IHashingPasswordUseCase _useCase
) : IMapping
{
    private readonly IHashingPasswordUseCase useCase = _useCase;

    public User MapUser(RegisterCommandRequestDto dto, string personId) =>
        User.Create
        (
            dto.Username,
            Email.Create(dto.Email).Value,
            useCase.Hashing(dto.Password),
            personId
        );

    public Person MapPerson(RegisterCommandRequestDto dto) =>
        Person.Create
        (
            Dni.Create(dto.Dni).Value,
            dto.Names,
            dto.Surnames
        );
}