﻿namespace DB.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public int? RoleId { get; set; }
}
