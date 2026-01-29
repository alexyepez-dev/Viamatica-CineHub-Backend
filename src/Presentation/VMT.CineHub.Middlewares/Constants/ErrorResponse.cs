namespace VMT.CineHub.Middlewares.Constants;
internal sealed record ErrorResponse
(
    int StatusCode,
    string Title,
    string Detail
);