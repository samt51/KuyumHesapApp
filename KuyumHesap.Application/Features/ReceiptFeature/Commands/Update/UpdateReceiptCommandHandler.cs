using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models.Dtos;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Application.Features.ReceiptFeature.Commands.Update
{
    public class UpdateReceiptCommandHandler : BaseHandler, IRequestHandler<UpdateReceiptCommandRequest, ResponseDto<UpdateReceiptCommandResponse>>
    {
        public UpdateReceiptCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<UpdateReceiptCommandResponse>> Handle(UpdateReceiptCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {


                // Start transaction for update
                await unitOfWork.OpenTransactionAsync(cancellationToken);

                var data = await unitOfWork.GetReadRepository<Receipt>().GetAsync(x => !x.IsDeleted && x.Id == request.Id, include: y => y.Include(v => v.Movements));


                var updateReceiptMap = mapper.Map<UpdateReceiptCommandRequest, Receipt>(request, data);
                await unitOfWork.GetWriteRepository<Receipt>().UpdateAsync(updateReceiptMap);
                await unitOfWork.SaveAsync(cancellationToken);

                // If there are movement DTOs, update existing ones or add new ones.
                // Incoming DTOs are expected to be in pairs (movement, counter movement) but single movement is supported.
                if (request.CreateMovementReceiptRequestDtos != null && request.CreateMovementReceiptRequestDtos.Any())
                {
                    // load existing movements tracked by EF for this receipt
                    var existingMovements = data.Movements ?? new List<Movements>();

                    var dtos = request.CreateMovementReceiptRequestDtos;

                    for (int i = 0; i < dtos.Count; i += 2)
                    {
                        var dto1 = dtos[i];
                        CreateMovementReceiptRequestDto? dto2 = (i + 1 < dtos.Count) ? dtos[i + 1] : null;

                        Movements hareket1Entity = null!;
                        Movements? hareket2Entity = null;

                        // handle first movement
                        if (dto1.MovementId > 0)
                        {
                            // update existing
                            hareket1Entity = existingMovements.FirstOrDefault(m => m.Id == dto1.MovementId) ?? new Movements();
                            mapper.Map(dto1, hareket1Entity);
                            hareket1Entity.ReceiptId = updateReceiptMap.Id;
                            hareket1Entity.UpdatedByUserId = hareket1Entity.Id > 0 ? 1 : null;

                            if (hareket1Entity.Id > 0)
                                await unitOfWork.GetWriteRepository<Movements>().UpdateAsync(hareket1Entity);
                            else
                            {
                                hareket1Entity.CreatedByUserId = 1;
                                await unitOfWork.GetWriteRepository<Movements>().AddAsync(hareket1Entity);
                            }
                        }
                        else
                        {
                            // create new
                            hareket1Entity = mapper.Map<CreateMovementReceiptRequestDto, Movements>(dto1, new Movements());
                            hareket1Entity.ReceiptId = updateReceiptMap.Id;
                            hareket1Entity.CreatedByUserId = 1;
                            await unitOfWork.GetWriteRepository<Movements>().AddAsync(hareket1Entity);
                        }

                        await unitOfWork.SaveAsync(cancellationToken);

                        // handle second movement (counter)
                        if (dto2 != null)
                        {
                            if (dto2.MovementId > 0)
                            {
                                hareket2Entity = existingMovements.FirstOrDefault(m => m.Id == dto2.MovementId) ?? new Movements();
                                mapper.Map(dto2, hareket2Entity);
                                hareket2Entity.ReceiptId = updateReceiptMap.Id;
                                hareket2Entity.UpdatedByUserId = hareket2Entity.Id > 0 ? 1 : null;

                                if (hareket2Entity.Id > 0)
                                    await unitOfWork.GetWriteRepository<Movements>().UpdateAsync(hareket2Entity);
                                else
                                {
                                    hareket2Entity.CreatedByUserId = 1;
                                    await unitOfWork.GetWriteRepository<Movements>().AddAsync(hareket2Entity);
                                }
                            }
                            else
                            {
                                hareket2Entity = mapper.Map<CreateMovementReceiptRequestDto, Movements>(dto2, new Movements());
                                hareket2Entity.ReceiptId = updateReceiptMap.Id;
                                hareket2Entity.CreatedByUserId = 1;
                                await unitOfWork.GetWriteRepository<Movements>().AddAsync(hareket2Entity);
                            }

                            await unitOfWork.SaveAsync(cancellationToken);

                            // ensure both sides reference each other
                            if (hareket1Entity != null && hareket2Entity != null)
                            {
                                hareket2Entity.CounterTransactionId = hareket1Entity.Id;
                                hareket1Entity.CounterTransactionId = hareket2Entity.Id;

                                await unitOfWork.GetWriteRepository<Movements>().UpdateAsync(hareket2Entity);
                                await unitOfWork.GetWriteRepository<Movements>().UpdateAsync(hareket1Entity);
                                await unitOfWork.SaveAsync(cancellationToken);
                            }
                        }
                    }
                }

                try
                {
                    await unitOfWork.CommitAsync(CancellationToken.None);
                }
                catch (TaskCanceledException)
                {
                    // If the incoming cancellation token was canceled (e.g. client disconnected / request timeout),
                    // try to commit without the external token to avoid leaving the transaction open.
                    // If that still fails, roll back and rethrow.
                    try
                    {
                        await unitOfWork.CommitAsync(CancellationToken.None);
                    }
                    catch
                    {
                        await unitOfWork.RollBackAsync(CancellationToken.None);
                        throw;
                    }
                }

                return new ResponseDto<UpdateReceiptCommandResponse>().Success();
            }
            catch (Exception)
            {
                // ensure transaction is rolled back on error and preserve original stack trace
                await unitOfWork.RollBackAsync(cancellationToken);
                throw;
            }
        }
    }
}
