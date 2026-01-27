namespace VMT.CineHub.Application.DTOs.Authentication.Login;
public sealed record LoginCommandRequestDto
(
    string Username,
    string Email,
    string Password
);