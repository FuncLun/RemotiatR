﻿using MediatR;
using System;
using System.ComponentModel;

namespace ContosoUniversity.Shared.Features.Departments
{
    public class Delete
    {
        public class Query : IRequest<Command>
        {
            public int Id { get; set; }
        }

        public class Command : IRequest
        {
            public string Name { get; set; }
            public decimal Budget { get; set; }
            public DateTime StartDate { get; set; }
            public int Id { get; set; }
            [DisplayName("Administrator")]
            public string AdministratorFullName { get; set; }
            public byte[] RowVersion { get; set; }
        }
    }
}
