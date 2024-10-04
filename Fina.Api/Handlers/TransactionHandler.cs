using Fina.Api.Data;
using Fina.Core.Enums;
using Fina.Core.Handlers;
using Fina.Core.Requests.Transactions;
using Fina.Core.Response;
using System.Transactions;
using Fina.Core.Model;
using Microsoft.EntityFrameworkCore;
using Fina.Core.Common;

namespace Fina.Api.Handlers
{
    public class TransactionHandler(AppDbContext Context) : ITransactionHandler
    {
        public async Task<Response<Core.Model.Transaction?>> CreateAsync(CreateTransactionRequest request)
        {
            if (request is { Type: ETransectionType.WithDraw, Amount: > 0 })
            {
                request.Amount *= -1;
            }

            try
            {
                var transaction = new Fina.Core.Model.Transaction()
                {
                    UserId = request.UserId,
                    Amount = request.Amount,
                    CategoryId = request.CategoryId,
                    CreateAT = DateTime.Now,
                    Title = request.Title,
                    PaidOrReceiveAt = request.PaidOrReceiveAt,
                    Type = request.Type

                };
                await Context.Transactions.AddAsync(transaction);
                await Context.SaveChangesAsync();
                return new Response<Fina.Core.Model.Transaction?>(transaction, 201, "Transação criada com sucesso !");

            }
            catch (Exception ex)
            {
                return new Response<Fina.Core.Model.Transaction?>(null, 500, "Não foi possivel criar a transação !");
                throw;
            }

        }

        public async Task<Response<Core.Model.Transaction?>> DeleteAsync(DeleteTransactionRequest request)
        {
            try
            {
                var transaction = await Context.Transactions.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);
                if (transaction is null)
                {
                    return new Response<Core.Model.Transaction?>(null, 404, "Transação nao encontrada !");
                }

                Context.Remove(transaction);
                await Context.SaveChangesAsync();
                return new Response<Core.Model.Transaction?>(null,_Message:"Transação excluida com suceso !");

            }
            catch (Exception ex)
            {
                return new Response<Core.Model.Transaction?>(null, 500, "Erro ao excluir a transação !");
                throw;
            }
        }

        public async Task<Response<Core.Model.Transaction?>> GetByIdAsync(GetTransactionByIdRequest request)
        {
            try
            {
                var transaction = await Context.Transactions.Include(x => x.Category).FirstOrDefaultAsync(x=>x.UserId == request.UserId && x.Id == request.Id);
                if (transaction is null)
                {
                    return new Response<Core.Model.Transaction?>(null,404,"Transação não encontrada !");
                }
                return new Response<Core.Model.Transaction?>(transaction);
            }
            catch (Exception)
            {
                return new Response<Core.Model.Transaction?>(null, 500, "Ocorreu um erro ao retorar a transação !");

                throw;
            }
        }

        public async Task<PagedResponse<List<Core.Model.Transaction>?>> GetByPeriodAsync(GetTransactionsByPeriodRequest request)
        {
            try
            {
                request.StatDate ??= DateTime.Now.GetFirstDay();
                request.EndDate ??= DateTime.Now.GetLastDay();
                var query = Context.Transactions.AsNoTracking().
                   Where(x => x.PaidOrReceiveAt >= request.StatDate &&
                   x.PaidOrReceiveAt <= request.EndDate &&
                   x.UserId == request.UserId).
                   OrderBy(x => x.PaidOrReceiveAt);

                var trsactions = await query.
                    Skip((request.PageNumber - 1) * request.PageZise).
                    Take(request.PageZise).
                    ToListAsync();
                var count = await query.CountAsync();


                return new PagedResponse<List<Core.Model.Transaction>?>(trsactions, count, request.PageNumber, request.PageZise);

            }
            catch (Exception)
            {

                return new PagedResponse<List<Core.Model.Transaction>?>(null,500,"Não foi Pssoivel obter as transações !");
                throw;
            }
        }

        public async Task<Response<Core.Model.Transaction?>> UpdateAsync(UpdateTransactionRequest request)
        {
            if (request is { Type: ETransectionType.WithDraw, Amount: > 0 })
            {
                request.Amount *= -1;
            }
            try
            {
                var transaction = await Context.Transactions.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);
                if (transaction is null)
                {
                    return new Response<Core.Model.Transaction?>(null, 404, "Transação nao encontrada !");
                }


                transaction.UserId = request.UserId;
                transaction.Amount = request.Amount;
                transaction.CategoryId = request.CategoryId;
                transaction.CreateAT = DateTime.Now;
                transaction.Title = request.Title;
                transaction.PaidOrReceiveAt = request.PaidOrReceiveAt;
                transaction.Type = request.Type;
                Context.Transactions.Update(transaction);
                await Context.SaveChangesAsync();
                return new Response<Core.Model.Transaction?>(transaction);

            }
            catch (Exception ex)
            {
                return new Response<Core.Model.Transaction?>(null, 500, "Erro a atualizar a transação !");
                throw;
            }
        }
    }
}
