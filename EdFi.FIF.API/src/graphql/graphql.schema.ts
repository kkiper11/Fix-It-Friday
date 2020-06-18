
/** ------------------------------------------------------
 * THIS FILE WAS AUTOMATICALLY GENERATED (DO NOT MODIFY)
 * -------------------------------------------------------
 */

/* tslint:disable */
/* eslint-disable */
export abstract class IQuery {
    abstract sections(): Section[] | Promise<Section[]>;

    abstract section(sectionkey: string): Section | Promise<Section>;

    abstract surveys(): Survey[] | Promise<Survey[]>;

    abstract survey(surveykey: string): Survey | Promise<Survey>;
}

export class Section {
    sectionkey?: string;
    schoolkey?: string;
    localcoursecode?: string;
    sessionname?: string;
    sectionidentifier?: string;
    schoolyear?: number;
}

export class Data {
    question?: string;
    answer?: string;
}

export class Metadata {
    timestamp?: string;
    studentschoolkey?: string;
    studentname?: string;
    studentemail?: string;
}

export class Question {
    question?: string;
}

export class Answer {
    metadata?: Metadata;
    data?: Data[];
}

export class SurveyJson {
    questions?: Question[];
    answers?: Answer[];
}

export class Survey {
    surveykey?: string;
    title?: string;
    info?: SurveyJson[];
}
