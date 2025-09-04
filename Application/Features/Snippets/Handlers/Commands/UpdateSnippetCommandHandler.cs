using Application.Contracts.Persistence;
using Application.DTOs.Snippet.Validators;
using Application.Features.Snippets.Requests.Commands;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Snippets.Handlers.Commands
{
    public class UpdateSnippetCommandHandler : IRequestHandler<UpdateSnippetCommand, CustomCommandResponse>
    {
        private readonly ISnippetRepository _snippetRepository;
        private readonly IMapper _mapper;

        public UpdateSnippetCommandHandler(ISnippetRepository urlTokenRepository, IMapper mapper)
        {
            _snippetRepository = urlTokenRepository;
            _mapper = mapper;
        }

        public async Task<CustomCommandResponse> Handle(UpdateSnippetCommand request, CancellationToken cancellationToken)
        {
            var response = new CustomCommandResponse();
            var validator = new UpdateSnippetDtoValidator();
            var validationResult = await validator.ValidateAsync(request.snippetDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Update failed";
                response.Errors = JsonConvert.SerializeObject(validationResult.Errors.Select(q => q.ErrorMessage).ToList());
                return response;
            }

            var snippet = await _snippetRepository.GetByIdAsync(request.Id);

            if (snippet == null)
            {
                response.Success = false;
                response.Message = "Update failed";
                response.Errors = "Snippet not found";
                return response;
            }


            _mapper.Map(request.snippetDto, snippet);

            await _snippetRepository.UpdateAsync(snippet);

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = snippet.Id;
            return response;
        }
    }
}
