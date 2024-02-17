using MiniUrl.Domain.ShortenedUrls.Url;

namespace MiniUrl.Application.Services;

public interface IUrlCodeGenerator
{
    Task<Code> Generate();
}