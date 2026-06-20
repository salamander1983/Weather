using Application.Dtos;

namespace Application.Queries;

public record GetHistoryQuery(int CityId) : IRequest<HistoryDto>;
