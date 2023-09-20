using System;
using System.Collections.Generic;
using System.Linq;
using TransactionAPI.Context;
using TransactionAPI.Models;

public class SeedData
{
    private readonly AppDbContext _context;

    public SeedData(AppDbContext context)
    {
        _context = context;
    }

    public void Initialize(IGroupRepository repo)
    {
        using (var transaction = _context.Database.BeginTransaction())
        {
            if (!_context.Groups.Any())
            {
                var groups = GetGroups();
                _context.Groups.AddRange(groups);

                var group1 = groups.First(g => g.Name == "Group 1");
                group1.Events = GetEvents();

                var user = GetUser();
                group1.User = user;

                _context.SaveChanges();
                transaction.Commit();
            }
        }
    }

    private List<Group> GetGroups()
    {
        return new List<Group>
        {
            new Group
            {
                Name = "Group 1",
                Address = "Address",
                City = "City",
                StateOrProvince = "StateOrProvince",
                Country = "Country",
                PostalCode = "Postal Code",
                UserId = 0,
                Events = new List<Event>()
            }
        };
    }

    private List<Event> GetEvents()
    {
        return new List<Event>
        {
            new Event
            {
                Date = DateTime.Now,
                Title = "Event 1",
                Description = "Description",
                GroupId = 0
            }
        };
    }

    private User GetUser()
    {
        return new User
        {
            Id = 1,
            FirstName = "Mogakolodi",
            LastName = "Tlotlang",
            Username = "mtlotlang",
            Password = "XaY0q+MI7M5G+z5BjNsCAaYpTn/7FMsDtTMW4ofcTtg8Tb01",
            Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJyb2xlIjoiVXNlciIsInVuaXF1ZV9uYW1lIjoibXRsb3RsYW5nIiwibmJmIjoxNjk0ODY1MTI2LCJleHAiOjE2OTQ4NjUxMzYsImlhdCI6MTY5NDg2NTEyNn0.LfmT0I9KnsCqHzganaKRoPQf0Wb0hD3_tjt5NxPLx_A",
            Role = "User",
            Email = "mtotlang@enkon.com",
            RefreshToken = "1vgTA6HrKrtDAwRjdfhRk3ZsUrZNw8xJ5fEQd6SXY+hgSjyhx1eThdGBoFgTJfxB2WQ9gZ1M5bK/+gPDSmFjTQ==",
            RefreshTokenExpiryTime = DateTime.Parse("2023-09-21T13:52:06.5851758"),
            // Note: The Groups property here is a list of Group names, not Group objects.
            // If User entity has a navigation property for Groups, this will need adjustment.
           
        };
    }

    internal static void Initialize(AppDbContext? db)
    {
        throw new NotImplementedException();
    }
}
