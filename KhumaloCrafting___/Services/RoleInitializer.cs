﻿using KhumaloCrafting___.Data;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

public interface IRoleInitializer
{
    Task InitializeAsync();
}

    public class RoleInitializer : IRoleInitializer
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleInitializer(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task InitializeAsync()
    {
        // Create roles if they don't exist
        if (!await _roleManager.RoleExistsAsync("Admin"))
        {
            await _roleManager.CreateAsync(new IdentityRole("Admin"));
        }
    }
}