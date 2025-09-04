using Application.Contracts.Persistence;
using Application.DTOs.Snippet.Validators;
using Application.Features.Snippets.Requests.Commands;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Newtonsoft.Json;

namespace Application.Features.Snippets.Handlers.Commands
{
    public class CreateSnippetCommandHandler : IRequestHandler<CreateSnippetCommand, CustomCommandResponse>
    {
        private readonly ISnippetRepository _snippetRepository;
        private readonly IMapper _mapper;

        public CreateSnippetCommandHandler(ISnippetRepository urlTokenRepository, IMapper mapper)
        {
            _snippetRepository = urlTokenRepository;
            _mapper = mapper;
        }

        public async Task<CustomCommandResponse> Handle(CreateSnippetCommand request, CancellationToken cancellationToken)
        {
            var response = new CustomCommandResponse();
            var validator = new CreateSnippetDtoValidator();
            var validationResult = await validator.ValidateAsync(request.snippetDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation failed";
                response.Errors = JsonConvert.SerializeObject(validationResult.Errors.Select(q => q.ErrorMessage).ToList());
                return response;
            }

            var snippet = _mapper.Map<Snippet>(request.snippetDto);

            snippet = await _snippetRepository.AddAsync(snippet);

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = snippet.Id;
            return response;
        }
    }
}
