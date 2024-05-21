import { User } from './user.model';
import { Course } from './course.model';

export interface Enrollment {
  EnrollmentId?: number;
  UserId: number;
  User: User;
  CourseId: number;
  Course: Course;
  EnrollmentDate: string;
  Status: string;
}
