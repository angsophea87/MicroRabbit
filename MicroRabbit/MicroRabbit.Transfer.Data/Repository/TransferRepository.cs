﻿using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Transfer.Data.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private readonly TransferDbContext _ctx;

        public TransferRepository(TransferDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(TransferLog transferLog)
        {
            _ctx.TransferLogs.Add(transferLog);
            _ctx.SaveChanges();
        }

        /*        public async Task Add(TransferLog transferLog)
                {
                    _ctx.TransferLogs.Add(transferLog);
                    await _ctx.SaveChangesAsync();
                }*/

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _ctx.TransferLogs;
        }
    }
}
