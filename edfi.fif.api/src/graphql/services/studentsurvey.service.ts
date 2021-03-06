// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

import { Injectable } from '@nestjs/common';
import { Repository } from 'typeorm';
import { InjectRepository } from '@nestjs/typeorm';
import SurveyEntity from '../entities/survey/survey.entity';
import StudentSurveyEntity from '../entities/survey/studentsurvey.entity';
import AnswersByStudentEntity from '../entities/survey/answersbystudent.entity';

@Injectable()
export default class StudentSurveyService {
  // eslint-disable-next-line no-useless-constructor
  constructor(
    @InjectRepository(SurveyEntity) private readonly FixItFridaySurveyRepository: Repository<SurveyEntity>,
    @InjectRepository(AnswersByStudentEntity)
    private readonly FixItFridayAnswersByStudentRepository: Repository<AnswersByStudentEntity>,
  ) {}

  async findSurvey(surveykey: string): Promise<SurveyEntity> {
    return this.FixItFridaySurveyRepository.findOne({ where: { surveykey } });
  }

  async findAnwsersByStudent(surveykey: string, studentschoolkey: string): Promise<AnswersByStudentEntity[]> {
    return this.FixItFridayAnswersByStudentRepository.createQueryBuilder('AnswersByStudent')
      .innerJoin(
        StudentSurveyEntity,
        'ss',
        `AnswersByStudent.surveykey = ss.surveykey and ss.surveykey='${surveykey}' 
          and AnswersByStudent.studentschoolkey = ss.studentschoolkey and ss.studentschoolkey='${studentschoolkey}'`,
      )
      .getMany();
  }
}
