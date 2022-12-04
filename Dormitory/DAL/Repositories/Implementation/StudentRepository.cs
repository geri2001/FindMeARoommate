﻿using DormitoryApi.DAL.Context;
using DormitoryApi.DAL.Models;
using DormitoryApi.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DormitoryApi.DAL.Repositories.Implementation;

public class StudentRepository : IStudentRepository
{
    protected DormitoryContext _context;
    public StudentRepository(DormitoryContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Student> AddAsync(Student student)
    {
        var result = _context.Students.Add(student);
        _ = await _context.SaveChangesAsync();
        return result.Entity;

    }

    public async Task<Student> DeleteAsync(int studentId)
    {
        var entity = await GetAsync(studentId);
        var result = _context.Students.Remove(entity);
            _ = await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Student> GetAsync(int studentId)
    {
        var result = await _context.Students.FirstOrDefaultAsync(s => s.Id == studentId);
        return result;
    }

    public async Task<List<Student>> GetAsync()
    {
        var result = await _context.Students.ToListAsync();
        return result;
    }

    public async Task<Student> UpdateAsync(Student student)
    {
        var result = _context.Students.Update(student);
        _ = await _context.SaveChangesAsync();
        return result.Entity;
    }
}
