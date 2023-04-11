import React, { Component } from 'react';
import { NavMenu } from './NavMenu';
import { StatesDropdown } from './StatesDropdown';

export class Layout extends Component {
  static displayName = Layout.name;

  render() {
    return (
      <div>
        <NavMenu />
        <StatesDropdown />
      </div>
    );
  }
}
