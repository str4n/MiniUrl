using MiniUrl.Domain.ShortenedUrls.Url;

namespace MiniUrl.Application.ShortenedUrls.Services;

public interface IUrlCodeGenerator
{
    Task<Code> Generate();
}