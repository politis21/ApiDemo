﻿using ApiDemo.Data.Dto;
using ApiDemo.Data.Models;

namespace ApiDemo.Data
{
    public class DirectorsRepository
    {
        private AppDbContext _context;

        public DirectorsRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddDirector(DirectorDto directorDto)
        {
            var director = new Director()
            {
                Id = directorDto.Id,
                Name = directorDto.Name,
                DateOfBirth = directorDto.DateOfBirth,
                Nationality = directorDto.Nationality,
                HasWonOscar = directorDto.HasWonOscar
            };
            _context.Add(director);
            _context.SaveChanges();
        }

        public List<Director> GetAllDirectors()
        {
            var director = _context.Directors.ToList();
            return director;
        }

        public void DeleteDirectorById(int id)
        {
            var director = _context.Directors.Find(id);
            if (director != null)
            {
                _context.Directors.Remove(director);
                _context.SaveChanges();
            }
        }
    }
}