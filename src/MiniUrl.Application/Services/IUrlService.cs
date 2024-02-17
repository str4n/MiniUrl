using MiniUrl.Application.DTO;
using MiniUrl.Application.Requests;
using MiniUrl.Domain.ShortenedUrls.Url;

namespace MiniUrl.Application.Services;

public interface IUrlService
{
    Task<ShortenedUrlDto> Shorten(ShortenUrlRequest request);
    Task<ShortenedUrlDto> GetUrl(Code code);
}