﻿using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;
using Dima.Core.Models;

namespace Dima.Core.Handlers;

public interface ITransactionHandler
{
    Task<Response<Transaction?>> CreateTransactionAsync(CreateTransactionRequest request);
    Task<Response<Transaction?>> UpdateTransactionAsync(UpdateTransactionRequest request);
    Task<Response<Transaction?>> DeleteTransactionAsync(DeleteTransactionRequest request);
    Task<Response<Transaction?>> GetTransactionByIdAsync(GetTransactionByIdRequest request);
    Task<PagedResponse<List<Transaction>?>> GetTransactionsByPeriodAsync(GetTransactionsByPeriodoRequest request);
}
