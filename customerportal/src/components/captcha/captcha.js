import React, {useEffect, useRef, useState} from 'react';
import PropTypes from 'prop-types';
import './captcha.css';
import {Button, TextField} from "@mui/material";

const Captcha = () => {
    const [captchaText, setCaptchaText] = useState('');
    const [userInput, setUserInput] = useState('');
    const canvasRef = useRef(null);
    useEffect(() => {
        const canvas = canvasRef.current;
        const ctx = canvas.getContext('2d');
        initializeCaptcha(ctx);
    }, []);


    const generateRandomChar = (min, max) =>
        String.fromCharCode(Math.floor
        (Math.random() * (max - min + 1) + min));

    const generateCaptchaText = () => {
        let captcha = '';
        for (let i = 0; i < 3; i++) {
            captcha += generateRandomChar(65, 90);
            captcha += generateRandomChar(97, 122);
            captcha += generateRandomChar(48, 57);
        }
        return captcha.split('').sort(
            () => Math.random() - 0.5).join('');
    };

    const drawCaptchaOnCanvas = (ctx, captcha) => {
        ctx.clearRect(0, 0, ctx.canvas.width, ctx.canvas.height);
        const textColors = ['green','red','black','brown'];
        const letterSpace = 175 / captcha.length;
        for (let i = 0; i < captcha.length; i++) {
            const xInitialSpace = 25;
            ctx.font = '32px Lucida Calligraphy';
            ctx.fillStyle = textColors[Math.floor(
                Math.random() * 4)];
            ctx.fillText(
                captcha[i],
                xInitialSpace + i * letterSpace,

                // Randomize Y position slightly
                Math.floor(Math.random() * 16 + 25),
                100
            );
        }
    };

    const initializeCaptcha = (ctx) => {
        setUserInput('');
        const newCaptcha = generateCaptchaText();
        setCaptchaText(newCaptcha);
        drawCaptchaOnCanvas(ctx, newCaptcha);
    };

    const handleUserInputChange = (e) => {
        setUserInput(e.target.value);
    };
    return(
        <div className="captcha">
            <div className="Canvas-header">
                <canvas ref={canvasRef}
                        width="250"
                        height="70">

                </canvas>
                <Button id="reload-button" color="success" className="reload-button" variant="contained" onClick={

                    (evnt) => {
                        // evnt.preventDefault()
                        initializeCaptcha(
                            canvasRef.current.getContext('2d')
                        )
                    }

                }>
                    Reload
                </Button>
            </div>
            <TextField
                type="text"
                id="user-input"
                placeholder="Enter the text in the image"
                value={userInput}
                fullWidth
                margin="dense"
                onChange={handleUserInputChange}></TextField>
        </div>
    )
};



export default Captcha;
