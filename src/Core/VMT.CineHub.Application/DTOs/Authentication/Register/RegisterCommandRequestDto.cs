namespace VMT.CineHub.Application.DTOs.Authentication.Register;
public sealed record RegisterCommandRequestDto
(
    string Dni,
    string Names,
    string Surnames,
    string Username,
    string Email,
    string Password
);