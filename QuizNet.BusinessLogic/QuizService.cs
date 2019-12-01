﻿using AutoMapper;
using QuizNet.BusinessLogic.DTOs;
using QuizNet.BusinessLogic.Interfaces;
using QuizNet.DataAccess;
using QuizNet.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace QuizNet.BusinessLogic
{
    public class QuizService : IQuizService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public QuizService(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }
        public List<QuestionDto> GenerateQuiz()
        {
            List<Question> questions = _questionRepository.GetAll().ToList();
            List<Question> randomQuestions = questions.OrderBy(x => Guid.NewGuid()).Take(2).ToList();

            List<QuestionDto> randomQuestionsDto = _mapper.Map<List<QuestionDto>>(randomQuestions);

            return randomQuestionsDto;
        }
    }
}