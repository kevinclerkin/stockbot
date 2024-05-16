import React from 'react'
import * as Yup from 'yup'

type Props = {}

type LoginFormInputs = {
    username: string
    password: string
};

const validation = Yup.object().shape({
    username: Yup.string().required('Username is required'),
    password: Yup.string().required('Password is required'),
});


const LoginPage = (props: Props) => {
  return (
    <div>LoginPage</div>
  )
}

export default LoginPage