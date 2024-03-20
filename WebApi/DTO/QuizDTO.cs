﻿using ApplicationCore.Models.QuizAggregate;

namespace WebApi.DTO
{
    public class QuizDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<QuizItemDTO> Items { get; set; }

        public static QuizDTO Of(Quiz quiz)
        {
            return new QuizDTO()
            {
                Id = quiz.Id,
                Title = quiz.Title,
                Items = quiz.Items.Select(item => QuizItemDTO.Of(item)).ToList()
            };
        }

    }
}
