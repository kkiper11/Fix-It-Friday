import React from 'react';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

import PageHeader from './pageHeader';
import { TeacherClassType } from './types/TeacherClassType';

const classesList: TeacherClassType[] = [
  { classId: '1', className: 'Class 1' },
  { classId: '2', className: 'Class 2' },
];

const TeacherScreen: React.FunctionComponent = () => {
  return (
    <Row>
      <Col xs={12}>
        <PageHeader TeacherClass={classesList} TeacherName="Jane Doe" />
        <hr />
      </Col>
    </Row>
  );
};

export default TeacherScreen;
