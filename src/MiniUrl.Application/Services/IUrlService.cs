using MiniUrl.Application.DTO;
using MiniUrl.Application.Requests;

namespace MiniUrl.Application.Services;

public interface IUrlService
{
    Task<ShortenedUrlDto> Shorten(ShortenUrlRequest request);
}