// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

import { Entity, Column, PrimaryColumn, ManyToMany, JoinTable } from 'typeorm';
import SectionEntity from './section.entity';

@Entity({ schema: 'fif', name: 'staff', synchronize: false })
export default class StaffEntity {
  @PrimaryColumn() staffkey: number;

  @Column() personaltitleprefix: string;

  @Column() firstname: string;

  @Column() middlename: string;

  @Column() lastsurname: string;

  @Column() staffuniqueid: string;

  @Column() electronicmailaddress: string;

  @ManyToMany(() => SectionEntity, section => section.sectionkey)
  @JoinTable()
  sections?: SectionEntity[];
}
