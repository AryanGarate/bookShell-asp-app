using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using Model;
using Org.BouncyCastle.Asn1.Ocsp;
using RespositoryLayer.CustomException;
using RespositoryLayer.Entity;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderBL _orderBL;
    private readonly IPaymentBL _paymentBL;
    private readonly ResponseML _responseML;

    public OrderController(IOrderBL orderBL, IPaymentBL paymentBL)
    {
        _orderBL = orderBL;
        _paymentBL = paymentBL;
        _responseML = new ResponseML();
    }

    [HttpPost("PlaceOrder")]
    public async Task<ActionResult<ResponseML>> PlaceOrder([FromBody] OrderDTO orderDTO)
    {
        try
        {
            if (orderDTO == null || !ModelState.IsValid)
            {
                _responseML.Success = false;
                _responseML.Message = "Invalid order data.";
                return BadRequest(_responseML);
            }

            var order = await _orderBL.PlaceOrder(orderDTO);

            _responseML.Success = true;
            _responseML.Message = "Order placed successfully.";
            _responseML.Data = order;

            return Ok(_responseML);
        }
        catch (OrderException ex)
        {
            _responseML.Success = false;
            _responseML.Message = ex.Message;
            return StatusCode(500, _responseML);
        }
    }

    [HttpGet("GetOrdersByUser/{userId}")]
    public async Task<ActionResult<ResponseML>> GetOrdersByUserId(int userId)
    {
        try
        {
            var orders = await _orderBL.GetOrdersByUserId(userId);

            _responseML.Success = true;
            _responseML.Message = "Orders fetched successfully.";
            _responseML.Data = orders;

            return Ok(_responseML);
        }
        catch (OrderException ex)
        {
            _responseML.Success = false;
            _responseML.Message = ex.Message;
            return StatusCode(500, _responseML);
        }
    }

    /* [HttpPost("VerifyPayment")]
     public async Task<ActionResult<ResponseML>> VerifyPayment([FromBody] PaymentDTO paymentDTO)
     {


         try
         {
             var isValid = await _paymentBL.VerifyPayment(paymentDTO.RazorpayPaymentId, paymentDTO.RazorpayOrderId, paymentDTO.RazorpaySignature);

             if (isValid)
             {
                 await _paymentBL.SavePaymentDetails(paymentDTO);
                 _responseML.Success = true;
                 _responseML.Message = "Payment verified and saved successfully.";
                 _responseML.Data = true;
                 return Ok(_responseML);
             }

             _responseML.Success = false;
             _responseML.Message = "Payment verification failed.";
             return BadRequest(_responseML);
         }
         catch (Exception ex)
         {
             _responseML.Success = false;
             _responseML.Message = ex.Message;
             return StatusCode(500, _responseML);
         }
     }*/

    [HttpPost("VerifyPayment")]
    public async Task<ActionResult<ResponseML>> VerifyPayment([FromBody] PaymentDTO paymentDTO)
    {
        if (string.IsNullOrEmpty(paymentDTO.RazorpayPaymentId) ||
            string.IsNullOrEmpty(paymentDTO.RazorpayOrderId) ||
            string.IsNullOrEmpty(paymentDTO.RazorpaySignature))
        {
            _responseML.Success = false;
            _responseML.Message = "Invalid payment verification request: Missing required fields.";
            return BadRequest(_responseML);
        }

        try
        {
            // Verify payment with Razorpay
            var isValid = await _paymentBL.VerifyPayment(paymentDTO.RazorpayPaymentId, paymentDTO.RazorpayOrderId, paymentDTO.RazorpaySignature);

            if (isValid)
            {
                // Save payment details in the database
                await _paymentBL.SavePaymentDetails(paymentDTO);
                _responseML.Success = true;
                _responseML.Message = "Payment verified and saved successfully.";
                _responseML.Data = true;
                return Ok(_responseML);
            }

            // Handle case where payment verification fails
            _responseML.Success = false;
            _responseML.Message = "Payment verification failed.";
            return BadRequest(_responseML);
        }
        catch (Exception ex)
        {
            // Log the exception (optional: you can log the exception for debugging purposes)
            // _logger.LogError(ex, "An error occurred during payment verification.");

            _responseML.Success = false;
            _responseML.Message = $"Internal server error: {ex.Message}";
            return StatusCode(500, _responseML);
        }
    }


}
