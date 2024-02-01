using MiniUrl.Domain.Url;

namespace MiniUrl.Application.Services;

public interface IUrlCodeGenerator
{
    Task<Code> Generate();
}