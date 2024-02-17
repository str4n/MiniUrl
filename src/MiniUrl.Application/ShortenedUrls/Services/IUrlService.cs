using MiniUrl.Application.ShortenedUrls.DTO;
using MiniUrl.Application.ShortenedUrls.Requests;
using MiniUrl.Domain.ShortenedUrls.Url;

namespace MiniUrl.Application.ShortenedUrls.Services;

public interface IUrlService
{
    Task<ShortenedUrlDto> Shorten(ShortenUrlRequest request);
    Task<ShortenedUrlDto> GetUrl(Code code);
}