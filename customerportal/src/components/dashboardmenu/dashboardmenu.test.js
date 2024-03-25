import React from 'react';
import { shallow } from 'enzyme';
import Dashboardmenu from './Dashboardmenu';

describe('<Dashboardmenu />', () => {
  let component;

  beforeEach(() => {
    component = shallow(<Dashboardmenu />);
  });

  test('It should mount', () => {
    expect(component.length).toBe(1);
  });
});
