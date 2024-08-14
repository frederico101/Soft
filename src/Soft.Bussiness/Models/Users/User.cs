﻿using Soft.Bussiness;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User: Entity
{
    [Key]
    public Guid Id { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }
}
