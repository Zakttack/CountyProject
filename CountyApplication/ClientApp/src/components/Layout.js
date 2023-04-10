import React, { Component } from 'react';
import { NavMenu } from './NavMenu';
import { StatesDropdown } from './StatesDropdown';

export class Layout extends Component {
  static displayName = Layout.name;

  render() {
    return (
      <div>
        <NavMenu />
        <p>Select a State: <StatesDropdown /></p>
      </div>
    );
  }
}
