import { Doctor } from './doctor.model'; // Import Doctor model

describe('Doctor', () => { // Change description to Doctor
  fit('Models should create doctor instance', () => { // Change fit to it and update test description
    const doctor: Doctor = { // Change recipe to doctor and Recipe to Doctor
      id: 1, // Adjust property name
      firstName: 'Test First Name', // Adjust property name
      lastName: 'Test Last Name', // Adjust property name
      specialization: 'Test Specialization', // Adjust property name
      phoneNumber: 'Test Phone Number', // Adjust property name
      email: 'test@email.com', // Adjust property name
      address: 'Test Address' // Adjust property name
    } as any;

    // Check if the doctor object exists
    expect(doctor).toBeTruthy();

    // Check individual properties of the doctor
    expect(doctor.id).toBe(1); // Adjust property name
    expect(doctor.firstName).toBe('Test First Name'); // Adjust property name
    expect(doctor.lastName).toBe('Test Last Name'); // Adjust property name
    expect(doctor.specialization).toBe('Test Specialization'); // Adjust property name
    expect(doctor.phoneNumber).toBe('Test Phone Number'); // Adjust property name
    expect(doctor.email).toBe('test@email.com'); // Adjust property name
    expect(doctor.address).toBe('Test Address'); // Adjust property name
  });
});
