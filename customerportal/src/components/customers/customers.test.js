import React from 'react';
import { shallow } from 'enzyme';
import Customers from './Customers';

describe('<Customers />', () => {
  let component;

  beforeEach(() => {
    component = shallow(<Customers />);
  });

  test('It should mount', () => {
    expect(component.length).toBe(1);
  });
});
