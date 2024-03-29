import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Projects } from './components/Projects';
import { TimeRegistrations } from './components/TimeRegistrations';

export const routes = <Layout>
    <Route exact path='/' component={ Home } />
    <Route path='/projects' component={ Projects } />
    <Route path='/timeregistrations' component={ TimeRegistrations } />
</Layout>;
