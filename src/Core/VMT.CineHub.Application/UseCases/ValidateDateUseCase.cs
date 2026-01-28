using VMT.CineHub.Application.Interfaces.UseCases;

namespace VMT.CineHub.Application.UseCases;
internal sealed class ValidateDateUseCase : IValidateDateUseCase
{
    public bool Verify(string format) => !DateTime.TryParse(format, out _);
}