import React from 'react';
import { Route, Navigate } from 'react-router-dom';

interface ProtectedRouteProps {
  element: React.ComponentType<any>;
  path: string;
}

const ProtectedRoute: React.FC<ProtectedRouteProps> = ({ element: Component, ...rest }) => {
  const token = localStorage.getItem('token');

  return (
    <Route
      {...rest}
      element={
        token ? (
          <Component {...rest} />
        ) : (
          <Navigate to="/" replace />
        )
      }
    />
  );
};

export default ProtectedRoute;