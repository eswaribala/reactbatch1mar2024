import React from 'react';
import { shallow } from 'enzyme';
import Captcha from './Captcha';

describe('<Captcha />', () => {
  let component;

  beforeEach(() => {
    component = shallow(<Captcha />);
  });

  test('It should mount', () => {
    expect(component.length).toBe(1);
  });
});
