﻿using Microsoft.AspNetCore.Identity;

namespace Dima.Api.Models;

public class User : IdentityUser
{
    public List<IdentityRole<long>>? Roles { get; set; }
}
