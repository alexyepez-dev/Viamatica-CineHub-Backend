namespace VMT.CineHub.Application.DTOs.Authentication.Login;
public sealed record LoginCommandResponseDto
(
    string Username,
    string Email,
    string Token
);