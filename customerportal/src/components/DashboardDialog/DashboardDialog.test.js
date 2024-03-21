import React from 'react';
import { shallow } from 'enzyme';
import DashboardDialog from './DashboardDialog';

describe('<DashboardDialog />', () => {
  let component;

  beforeEach(() => {
    component = shallow(<DashboardDialog />);
  });

  test('It should mount', () => {
    expect(component.length).toBe(1);
  });
});
