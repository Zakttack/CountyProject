import React, { Component } from 'react';
import { StatesDropdown } from './StatesDropdown';


export class Home extends Component {
  static displayName = Home.name;

  constructor() {
    
  }
  render() {
    return (
      <div>
        <p>Select a state: </p> 
        <StatesDropdown />
      </div>
    );
  }
}
